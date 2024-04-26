import { PetDto } from "../pet/PetDto";
import { DonorDto } from "./DonorDto";

export interface DonorPetAudit {
    id: number;
    lastDonation: Date
   version: number;
   newTotalDonation: number;
   oldTotalDonation: number;
   isDeleted: boolean;
   donor: DonorDto
   pet: PetDto
}
