import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdoptComponent } from './adopt/adopt.component';
import { ContactComponent } from './contact/contact.component';
import { DonateComponent } from './donate/donate.component';
import { NewsComponent } from './news/news.component';
import { VolunteerComponent } from './volunteer/volunteer.component';
import { AdoptPagesComponent } from './adopt-pages.component';
import { AdoptPetDetailComponent } from './adopt-pet-detail/adopt-pet-detail.component';
import { VirtualAdoptionComponent } from './virtual-adoption/virtual-adoption.component';

export const adoptRoutes: Routes = [
	{
		path: '',
		component: AdoptPagesComponent,
		children: [
			{ path: '', component: HomeComponent, title: 'Trang chủ' },
			{ path: 'adopt', component: AdoptComponent, title: 'Nhận nuôi' },
			{ path: 'adopt-pet-detail/:id', component: AdoptPetDetailComponent, title: 'Chi tiết nhận nuôi' },
			{ path: 'virtual-adoption', component: VirtualAdoptionComponent, title: 'Nhận nuôi ảo' },
			{ path: 'contact', component: ContactComponent, title: 'Liên hệ' },
			{ path: 'donate', component: DonateComponent, title: 'Ủng hộ' },
			{ path: 'news', component: NewsComponent, title: 'Tin tức' },
			{ path: 'volunteer', component: VolunteerComponent, title: 'Tình nguyện viên' },
			{ path: '**', redirectTo: '' },
		],

		// children: [
		// 	{ path: '', component: DonateComponent, title: 'Ủng hộ' },
		// 	{ path: 'adopt', component: AdoptComponent, title: 'Nhận nuôi' },
		// ],
	},
];
