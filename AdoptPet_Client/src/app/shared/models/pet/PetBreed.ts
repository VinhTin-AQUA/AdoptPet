import { Breed } from '../breed/breed';

export interface PetBreed {
	id: number;
	breedId: number;
	breed: Breed;
	petId: number;
	isDeleted: boolean;
}
