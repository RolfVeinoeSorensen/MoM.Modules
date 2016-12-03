import {Component, OnInit} from "@angular/core";
import {Router} from "@angular/router";;
import {NavigationMenuService} from "../api/navigationmenuservice";
import {NavigationMenuDto} from "../dtos/NavigationMenuDto";
import {NavigationMenuItemDto} from "../dtos/NavigationMenuItemDto";
import {NavigationMenuRequestDto} from "../dtos/NavigationMenuRequestDto";

@Component({
    selector: "admin-navigation",
    templateUrl: "/cms/widgets/adminnavigation",
    providers: [NavigationMenuService]
})
export class NavigationAdminComponent implements OnInit {
    isLoading: boolean = false;
    currentPageId: number = 0;
    items: NavigationMenuItemDto[];
    hasError: boolean = false;
    errorMessage: string;
    requestDto: NavigationMenuRequestDto;

    constructor(
        private service: NavigationMenuService,
        private router: Router
    ) { }

    ngOnInit() {
        this.loadMenu();
    }

    isLinkActive(instruction: any[]): boolean {
        return false;
        //return this.router.isRouteActive(this.router.generate(instruction));
    }

    onMenuItemClick(item: NavigationMenuItemDto) {
        this.router.navigate([item.routerLink, {}]);
        this.currentPageId = item.navigationMenuItemId;
        this.loadMenu();
    }

    loadMenu() {
        this.isLoading = true;
        //this.requestDto = {
        //    id: this.currentPageId, name: "admin", routeName: this.router.currentInstruction.component.routeName
        //};
        console.log(this.requestDto);
        this.service.getMenuItemsByMenuNameAndMenuItemId(this.requestDto).subscribe(
            navitems => {
                this.items = navitems;
                this.isLoading = false;
            },
            error => {
                this.hasError = true;
                this.errorMessage = <any>error;
                this.isLoading = false;
            }
        );
    }
}