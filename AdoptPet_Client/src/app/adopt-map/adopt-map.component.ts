// import { Component, OnInit } from '@angular/core';
// import { Map, NavigationControl, Popup, Marker, GeolocateControl } from 'maplibre-gl';
// import { MapService } from '../services/map.service';
// import { ActivatedRoute, RouterLink } from '@angular/router';
// import { DatePipe } from '@angular/common';
// import { environment } from '../../environments/environment.development';
// import { HeaderComponent } from '../../app/components/header/header.component';
// import { FooterComponent } from '../../app/components/footer/footer.component';

// interface Feature {
//   type: 'Feature';
//   geometry: Geometry;
//   properties: Properties;
// }

// interface Geometry {
//   type: 'Point';
//   coordinates: [number, number];
// }

// interface AvatarUrl {
//   id: number;
//   imgPath: string;
//   petId: number;
//   isDeleted: boolean;
//   imageType: number;
//   pet: null; // This can be another type if you have more details about 'pet'
// }

// interface Properties {
//   id: number;
//   name: string;
//   owner: null | string; // This can be another type if you have more details about 'owner'
//   avatarUrl: string;
//   entityType: 'pet' | 'owner'; // Can be a string literal or an enum for more type safety
//   description?: string;
//   age?: number; // Optional since not all pets may have a known age
//   weight?: number; // Optional and could be null or undefined if unknown
//   gender?: 'Male' | 'Female' | 'Unknown'; 
//   desexed?: boolean;
//   wormed?: boolean;
//   vaccined?: boolean;
//   microchipped?: boolean;
//   entryDate?: Date; // Use Date type, assuming you manage date objects
//   status?: string; // This could be an enum if you have specific status values
// }

// @Component({
//   selector: 'app-adopt-map',
//   standalone: true,
//   imports: [RouterLink, DatePipe, HeaderComponent, FooterComponent],
//   templateUrl: './adopt-map.component.html',
//   styleUrls: ['./adopt-map.component.scss']
// })
// export class AdoptMapComponent implements OnInit {
//   private map!: Map;
//   features: Feature[] = [];
//   markers: { feature: Feature, marker: Marker }[] = [];
//   constructor(private mapService: MapService) { }

//   ngOnInit(): void {
//   }

//   ngAfterViewInit() {
//     this.initializeMap();
//   }

//   private initializeMap() {
//     this.map = new Map({
//       container: 'map',
//       style: 'https://api.maptiler.com/maps/streets/style.json?key=X4vyOCm1B17YgmHYreDM',
//       center: [-100.16207064288109,41.13218242824093],//[106.63197345922089, 10.812111265685385], // Set initial center
//       zoom: 7 // Set initial zoom
//     });

//     this.map.addControl(new NavigationControl());
//     // Add geolocate control to the map.
//     this.map.addControl(
//       new GeolocateControl({
//           positionOptions: {
//               enableHighAccuracy: true
//           },
//           trackUserLocation: true
//       })
//   );

//     this.map.on('load', () => {
//       this.mapService.getGeoJson().subscribe(data => {
//         this.map.addSource('pets-owners', {
//           type: 'geojson',
//           data: data
//         });
   
//         this.features = data.features;
//         this.features.forEach((feature) => {
//           let popupContent = '';
//           if (feature.properties.entityType === 'pet') {
//             popupContent = `
//             <div style="font-family: Arial, sans-serif; max-height: 300px; overflow-y: auto; overflow-x: hidden;">
//               <img src="${environment.baseImgUrl + feature.properties.avatarUrl}" alt="${feature.properties.name}'s Avatar" style="width: 100%; height: auto; display: block; margin-bottom: 10px;">
//               <h3 style="font-size: 2em; text-align: center; margin-top: 0; margin-bottom: 10px;">
//                 <a href="${environment.petDetailUrl+feature.properties.id}" style="text-decoration: none; color: inherit;">
//                   ${feature.properties.name}
//                 </a>
//               </h3>
//               <p><strong>Owner:</strong> ${feature.properties.owner || 'No owner listed'}</p>
//               <p><strong>Description:</strong> ${feature.properties.description || 'No description'}</p>
//               <p><strong>Age:</strong> ${feature.properties.age || 'N/A'} years</p>
//               <p><strong>Weight:</strong> ${feature.properties.weight || 'N/A'} kg</p>
//               <p><strong>Gender:</strong> ${feature.properties.gender || 'N/A'}</p>
//               <p><strong>Desexed:</strong> ${feature.properties.desexed ? 'Yes' : 'No'}</p>
//               <p><strong>Wormed:</strong> ${feature.properties.wormed ? 'Yes' : 'No'}</p>
//               <p><strong>Vaccinated:</strong> ${feature.properties.vaccined ? 'Yes' : 'No'}</p>
//               <p><strong>Microchipped:</strong> ${feature.properties.microchipped ? 'Yes' : 'No'}</p>
//               <p><strong>Entry Date:</strong> ${feature.properties.entryDate ? new Date(feature.properties.entryDate).toLocaleDateString() : 'N/A'}</p>
//               <p><strong>Status:</strong> ${feature.properties.status || 'N/A'}</p>
//             </div>
//             `;
//           } else if (feature.properties.entityType === 'owner') {
//             popupContent = `
//               <div>
//                 <img src="${environment.baseImgUrl + feature.properties.avatarUrl}" alt="${feature.properties.name}'s Avatar" width="200" height="200">
//                 <h3 style="font-size: 2em; text-align: center; margin-top: 0; margin-bottom: 10px;">
//                 <a href="${environment.petDetailUrl+feature.properties.id}" style="text-decoration: none; color: inherit;">
//                   ${feature.properties.name}
//                 </a>
//               </h3>
//               </div>
//             `;
//           }
   
//           const popup = new Popup({ offset: 25 }).setHTML(popupContent);
//           const el = document.createElement('div');
//           const img = document.createElement('img');
//           img.src = environment.baseImgUrl + feature.properties.avatarUrl;
//           img.style.width = '50px';
//           img.style.height = '50px';
//           img.style.border = '2px solid #fff';
//           img.style.borderRadius = '0%';
//           img.style.boxShadow = '0 0 10px rgba(0, 0, 0, 0.5)';
   
//           el.appendChild(img);
   
//           const pointer = document.createElement('div');
//           pointer.style.width = '0';
//           pointer.style.height = '0';
//           pointer.style.borderLeft = '10px solid transparent';
//           pointer.style.borderRight = '10px solid transparent';
//           pointer.style.borderTop = '10px solid #fff';
//           pointer.style.position = 'absolute';
//           pointer.style.left = '50%';
//           pointer.style.transform = 'translateX(-50%)';
//           pointer.style.top = '50px';
   
//           el.appendChild(pointer);
   
//           const marker = new Marker({ element: el })
//             .setLngLat([feature.geometry.coordinates[0], feature.geometry.coordinates[1]])
//             .setPopup(popup)
//             .addTo(this.map!);
          
//           this.markers.push({ feature, marker });
//         });
//       });
//     });
   
//   }
//   onSearch(event: any): void {
//     const searchTerm = event.target.value.toLowerCase();
//     this.markers.forEach(({ feature, marker }) => {
//       const isVisible = feature.properties.name.toLowerCase().includes(searchTerm);
//       marker.getElement().style.display = isVisible ? 'block' : 'none';
//     });
//   }
  
// }
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Map, NavigationControl, Popup, Marker, GeolocateControl,FullscreenControl } from 'maplibre-gl';
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
export class AdoptMapComponent implements OnInit {
  private map!: Map;
  features: Feature[] = [];
  markers: Marker[] = [];
  searchTerm: string = '';

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
    this.map.addControl(new GeolocateControl({
      positionOptions: {
        enableHighAccuracy: true
      },
      trackUserLocation: true
    }));

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

  private createPopupContent(properties: Properties): string {
    if (properties.entityType === 'pet') {
      return `
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
    } else if (properties.entityType === 'owner') {
      return `
        <div>
          <img src="${environment.baseImgUrl + properties.avatarUrl}" alt="${properties.name}'s Avatar" width="200" height="200">
          <h3 style="font-size: 2em; text-align: center; margin-top: 0; margin-bottom: 10px;">
            <a href="${environment.petDetailUrl + properties.id}" style="text-decoration: none; color: inherit;">
              ${properties.name}
            </a>
          </h3>
        </div>
      `;
    }
    return '';
  }

  searchMarkers(event : any) {
    const searchKeywords = event.target.value.toLowerCase().split('');
    this.markers.forEach(marker => {
      const feature = this.features[this.markers.indexOf(marker)];
      const markerName = feature.properties.name.toLowerCase();
      const isVisible = searchKeywords.every((keyword: string) => markerName.includes(keyword));
      marker.getElement().style.display = isVisible ? 'block' : 'none';
    });
  }
  
}


