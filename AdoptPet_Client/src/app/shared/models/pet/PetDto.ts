import { PetBreed } from "./PetBreed";
import { PetColour } from "./PetColour";


export interface PetDto {
	id: number;
	petName: string;
	petDescription: string;
	petWeight: number;
	petAge: number;
	petGender: number;
	petDesexed: number;
	petWormed: number;
	petVaccined: number;
	petMicrochipped: number;
	petEntryDate: Date;
	status: number;
	isDeleted: number;

	// khoa ngoai
	volunteerId: number;
	ownerId: number;

	petBreeds: PetBreed[];
	petColours: PetColour[];
}
