import { Location } from '../location/location';
import { VolunteerRole } from './volunteer-role';

export interface Volunteer {
	id: number;
	dateStart: Date;
	isDeleted: boolean;
	location: Location;
	roles: VolunteerRole[]
}