import {NavigationMenuItemDto} from "./NavigationMenuItemDto";
import {NavigationMenuDto} from "./NavigationMenuDto";

export interface NavigationMenuItemDto {
    navigationMenuItemId: number;
    parent: NavigationMenuItemDto;
    name: string;
    displayName: string;
    routerLink: string;
    iconClass: string;
    sortOrder: number;
    navigationMenu: NavigationMenuDto;
    isParent: boolean;
}
