import { Color } from '../color/Color';

export interface PetColour {
	id: number;
	colourId: number;
	colour: Color;
	isDeleted: boolean;
}
