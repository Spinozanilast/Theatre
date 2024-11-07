export default interface User {
    Id: string;
    userData: UserData;
}

export interface UserData {
    firstName: string;
    email: string;
    phoneNumber: string;
}
