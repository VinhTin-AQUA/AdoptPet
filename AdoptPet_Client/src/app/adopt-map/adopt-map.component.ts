import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Map, NavigationControl, Popup, Marker, GeolocateControl, FullscreenControl } from 'maplibre-gl';
import { MapService } from '../services/map.service';
import { environment } from '../../environments/environment.development';
import { RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { HeaderComponent } from '../../app/components/header/header.component';
import { FooterComponent } from '../../app/components/footer/footer.component';

interface Feature {
  type: 'Feature';
  geometry: Geometry;
  properties: Properties;
}

interface Geometry {
  type: 'Point';
  coordinates: [number, number];
}

interface Properties {
  id: number;
  name: string;
  owner: string | null;
  avatarUrl: string;
  entityType: 'pet' | 'owner';
  description?: string;
  age?: number;
  weight?: number;
  gender?: 'Male' | 'Female' | 'Unknown';
  desexed?: boolean;
  wormed?: boolean;
  vaccined?: boolean;
  microchipped?: boolean;
  entryDate?: Date;
  status?: string;
}

@Component({
  selector: 'app-adopt-map',
  standalone: true,
  imports: [RouterLink, DatePipe, HeaderComponent, FooterComponent],
  templateUrl: './adopt-map.component.html',
  styleUrls: ['./adopt-map.component.scss']
})
export class AdoptMapComponent implements OnInit, AfterViewInit {
  private map!: Map;
  features: Feature[] = [];
  markers: Marker[] = [];
  searchTerm: string = '';
  userLocation: [number, number] | null = null;

  constructor(private mapService: MapService) { }

  ngOnInit(): void { }

  ngAfterViewInit() {
    this.initializeMap();
  }

  private initializeMap() {
    this.map = new Map({
      container: 'map',
      style: 'https://api.maptiler.com/maps/streets/style.json?key=X4vyOCm1B17YgmHYreDM',
      center: [106.63197345922089, 10.812111265685385],
      zoom: 7
    });

    this.map.addControl(new NavigationControl());
    this.map.addControl(new FullscreenControl());
    const geolocateControl = new GeolocateControl({
      positionOptions: {
        enableHighAccuracy: true
      },
      trackUserLocation: true
    });
    this.map.addControl(geolocateControl);

    geolocateControl.on('geolocate', (e: any) => {
      this.userLocation = [e.coords.longitude, e.coords.latitude];
      this.calculateDistances();
    });

    this.map.on('load', () => {
      this.mapService.getGeoJson().subscribe(data => {
        this.features = data.features;
        this.addMarkers();
      });
    });
  }

  private addMarkers() {
    this.features.forEach(feature => {
      const el = document.createElement('div');
      const img = document.createElement('img');
      img.src = environment.baseImgUrl + feature.properties.avatarUrl;
      img.style.width = '50px';
      img.style.height = '50px';
      img.style.border = '2px solid #fff';
      img.style.borderRadius = '0%';
      img.style.boxShadow = '0 0 10px rgba(0, 0, 0, 0.5)';

      el.appendChild(img);

      const pointer = document.createElement('div');
      pointer.style.width = '0';
      pointer.style.height = '0';
      pointer.style.borderLeft = '10px solid transparent';
      pointer.style.borderRight = '10px solid transparent';
      pointer.style.borderTop = '10px solid #fff';
      pointer.style.position = 'absolute';
      pointer.style.left = '50%';
      pointer.style.transform = 'translateX(-50%)';
      pointer.style.top = '50px';

      el.appendChild(pointer);

      const popupContent = this.createPopupContent(feature.properties);
      const popup = new Popup({ offset: 25 }).setHTML(popupContent);

      const marker = new Marker({ element: el })
        .setLngLat([feature.geometry.coordinates[0], feature.geometry.coordinates[1]])
        .setPopup(popup)
        .addTo(this.map);

      this.markers.push(marker);
    });
  }

  private createPopupContent(properties: Properties, distance?: number): string {
    let content = `
      <div style="font-family: Arial, sans-serif; max-height: 300px; overflow-y: auto; overflow-x: hidden;">
        <img src="${environment.baseImgUrl + properties.avatarUrl}" alt="${properties.name}'s Avatar" style="width: 100%; height: auto; display: block; margin-bottom: 10px;">
        <h3 style="font-size: 2em; text-align: center; margin-top: 0; margin-bottom: 10px;">
          <a href="${environment.petDetailUrl + properties.id}" style="text-decoration: none; color: inherit;">
            ${properties.name}
          </a>
        </h3>
        <p><strong>Owner:</strong> ${properties.owner || 'No owner listed'}</p>
        <p><strong>Description:</strong> ${properties.description || 'No description'}</p>
        <p><strong>Age:</strong> ${properties.age || 'N/A'} years</p>
        <p><strong>Weight:</strong> ${properties.weight || 'N/A'} kg</p>
        <p><strong>Gender:</strong> ${properties.gender || 'N/A'}</p>
        <p><strong>Desexed:</strong> ${properties.desexed ? 'Yes' : 'No'}</p>
        <p><strong>Wormed:</strong> ${properties.wormed ? 'Yes' : 'No'}</p>
        <p><strong>Vaccinated:</strong> ${properties.vaccined ? 'Yes' : 'No'}</p>
        <p><strong>Microchipped:</strong> ${properties.microchipped ? 'Yes' : 'No'}</p>
        <p><strong>Entry Date:</strong> ${properties.entryDate ? new Date(properties.entryDate).toLocaleDateString() : 'N/A'}</p>
        <p><strong>Status:</strong> ${properties.status || 'N/A'}</p>
      </div>
    `;
    if (distance !== undefined) {
      content += `<p><strong>Distance:</strong> ${distance.toFixed(2)} km</p>`;
    }
    return content;
  }

  private calculateDistances() {
    if (!this.userLocation) return;

    this.features.forEach((feature, index) => {
      const distance = this.calculateDistance(this.userLocation!, feature.geometry.coordinates);
      const popupContent = this.createPopupContent(feature.properties, distance);
      this.markers[index].getPopup().setHTML(popupContent);
    });
  }

  private calculateDistance(coord1: [number, number], coord2: [number, number]): number {
    const R = 6371; // Radius of the Earth in km
    const dLat = this.deg2rad(coord2[1] - coord1[1]);
    const dLon = this.deg2rad(coord2[0] - coord1[0]);
    const a =
      Math.sin(dLat / 2) * Math.sin(dLat / 2) +
      Math.cos(this.deg2rad(coord1[1])) * Math.cos(this.deg2rad(coord2[1])) *
      Math.sin(dLon / 2) * Math.sin(dLon / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    const distance = R * c; // Distance in km
    return distance;
  }

  private deg2rad(deg: number): number {
    return deg * (Math.PI / 180);
  }

  searchMarkers(event: any) {
    const searchKeywords = event.target.value.toLowerCase().split('');
    this.markers.forEach(marker => {
      const feature = this.features[this.markers.indexOf(marker)];
      const markerName = feature.properties.name.toLowerCase();
      const isVisible = searchKeywords.every((keyword: string) => markerName.includes(keyword));
      marker.getElement().style.display = isVisible ? 'block' : 'none';
    });
  }
}
