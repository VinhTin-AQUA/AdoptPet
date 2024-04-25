import { LocationDto } from "../location/LocationDto";

export interface DonorDto {
	id: number;
	name: string;
	totalDonation: number;


	isDeleted: boolean;
	location: LocationDto
}
