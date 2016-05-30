import {Component, OnInit} from "@angular/core";
import {TAB_DIRECTIVES, BUTTON_DIRECTIVES} from "ng2-bootstrap/ng2-bootstrap";
import {SiteSettings, Theme, Authentication, Facebook, Google, Microsoft, Twitter, Logo, Email} from "../interfaces/iSiteSettings";
import {AdminSiteSettingsService} from "../services/adminsitesettingsservice";
import {Router, RouteParams} from "@angular/router-deprecated";

@Component({
    selector: "mom-admin-settings",
    directives: [TAB_DIRECTIVES, BUTTON_DIRECTIVES],
    providers: [AdminSiteSettingsService],
    templateUrl: "/cms/pages/adminsettings"
})
export class AdminSettingsComponent implements OnInit {
    siteSettings: SiteSettings;
    isLoading: boolean = false;

    constructor(
        private service: AdminSiteSettingsService,
        private router: Router,
        private routeParams: RouteParams
    ) { }

    ngOnInit() {
        this.getSiteSettings();
        //this.message = "Welcome to EasyModules.NET"
    }

    getSiteSettings() {
        this.isLoading = true;
        this.service.getSiteSettings(json => {
            if (json) {
                this.siteSettings = json;
                this.isLoading = false;
                console.log(this.siteSettings);
            }
        });
    }

    onSaveSiteSettings() {
        this.isLoading = true;
        this.service.saveSiteSettings(this.siteSettings, json => {
            if (json) {
                this.siteSettings = json;
                this.isLoading = false;
                console.log(this.siteSettings);
            }
        });
    }

    onCancel() {
        //this.router.navigate(["../AdminSettings"]);
    }
}