import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import {Router, RouteParams} from "@angular/router-deprecated";;
import {NavigationService} from "../services/navigationservice";
import {NavigationMenu, NavigationMenuItem} from "../interfaces/inavigation";

@Component({
    selector: "admin-navigation",
    templateUrl: "/cms/widgets/adminnavigation",
    providers: [NavigationService],
    directives: [CORE_DIRECTIVES]
})
export class NavigationAdminComponent implements OnInit {
    isLoading: boolean = false;
    currentPageId: number = 0;
    items: NavigationMenuItem;

    constructor(
        private service: NavigationService,
        private router: Router
    ) { }

    ngOnInit() {
        this.loadMenu();
    }

    isLinkActive(instruction: any[]): boolean {
        return this.router.isRouteActive(this.router.generate(instruction));
    }

    onMenuItemClick(item: NavigationMenuItem) {
        this.router.navigate([item.routerLink, {}]);
        this.currentPageId = item.navigationMenuItemId;
        this.loadMenu();
    }

    loadMenu() {
        this.isLoading = true;
        this.service.getMenuItemsByMenuNameAndMenuItemId("admin", this.currentPageId, this.router.currentInstruction.component.routeName, json => {
            if (json) {
                this.items = json;
                this.isLoading = false;
            }
        });
    }
}