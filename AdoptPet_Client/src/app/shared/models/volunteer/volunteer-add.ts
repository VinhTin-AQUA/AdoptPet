import { Location } from '../location/location';

export interface VolunteerAdd {
	userEmail: string;
	location: Location;
	roleId: number;
}
