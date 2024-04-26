export interface UserDto {
    id: string;
    email: string;
    phoneNumber: string;
    emailConfirmed: string;
    phoneNumberConfirmed: string;
    lockoutEnd: Date | null;
    lockoutEnabled: boolean;
    lastName: string;
    firstName: string;
    roles: string[];
}