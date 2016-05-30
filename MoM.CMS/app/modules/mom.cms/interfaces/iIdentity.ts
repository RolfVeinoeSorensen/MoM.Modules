export interface User {
        id: string;
        userName: string;
        email: string;
        emailConfirmed: boolean;
        accessFailedCount: number;
        concurrencyStamp: string;
        lockoutEnabled: boolean;
        lockoutEnd : Date;
        phoneNumber: string;
        phoneNumberConfirmed: boolean;
        twoFactorEnabled: boolean;
        roles: [Role];
}

export interface Role {
        id: string;
        name: string;
        concurrencyStamp: string;
        normalizedName: string;
        users: [User];
}