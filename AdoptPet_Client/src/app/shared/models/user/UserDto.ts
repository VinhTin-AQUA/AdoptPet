export interface UserDto {
    email: string;
    phoneNumber: string;
    emailConfirmed: string;
    phoneNumberConfirmed: string;
    lockoutEnd: Date;
    lockoutEnabled: boolean;
    lastName: string;
    firstName: string;
    roles: string[];
}