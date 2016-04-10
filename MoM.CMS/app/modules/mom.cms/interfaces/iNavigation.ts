export interface NavigationMenu {
        navigationMenuId: number;
        name: string;
        displayName: string;
        iconClass: string;
}

export interface NavigationMenuItem {
        navigationMenuItemId: number;
        parent: NavigationMenuItem;
        name: string;
        displayName: string;
        routerLink: string;
        iconClass: string;
        sortOrder: number;
        navigationMenu: NavigationMenu;
}