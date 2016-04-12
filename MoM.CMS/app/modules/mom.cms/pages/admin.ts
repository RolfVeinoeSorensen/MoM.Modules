﻿import {Component, OnInit} from "angular2/core";
import {AsyncRoute, RouteConfig, RouterLink, RouterOutlet, RouteData, Router, ROUTER_DIRECTIVES} from 'angular2/router';
import {NavigationAdminComponent} from "../widgets/navigationadmin";

declare var System: any;

@Component({
    selector: "mom-admin",
    templateUrl: "/cms/pages/admin",
    directives: [RouterOutlet, RouterLink, NavigationAdminComponent]
})
@RouteConfig([
    new AsyncRoute({
        path: "/",
        name: "AdminInfo",
        useAsDefault: true,
        data: { includeInMenu: true, icon: "fa fa-info-circle fa-2x", title: "Info" },
        loader: () => System.import("app/modules/MoM.CMS/pages/admininfo").then(c => c["AdminInfoComponent"])
        }),
    new AsyncRoute({
        path: "/content",
        name: "AdminContent",
        useAsDefault: false,
        data: { includeInMenu: true, icon: "fa fa-sitemap fa-2x", title: "Content" },
        loader: () => System.import("app/modules/MoM.CMS/pages/admincontent").then(c => c["AdminContentComponent"])
        }),
    new AsyncRoute({
        path: "/security",
        name: "AdminSecurity",
        useAsDefault: false,
        data: { includeInMenu: true, icon: "fa fa-sitemap fa-2x", title: "Settings" },
        loader: () => System.import("app/modules/MoM.CMS/pages/adminsecurity").then(c => c["AdminSecurityComponent"])
    }),
    new AsyncRoute({
        path: "/settings",
        name: "AdminSettings",
        useAsDefault: false,
        data: { includeInMenu: true, icon: "fa fa-sitemap fa-2x", title: "Settings" },
        loader: () => System.import("app/modules/MoM.CMS/pages/adminsettings").then(c => c["AdminSettingsComponent"])
    }),
    new AsyncRoute({
        path: "/modules",
        name: "AdminModules",
        useAsDefault: false,
        data: { includeInMenu: true, icon: "fa fa-sitemap fa-2x", title: "Modules" },
        loader: () => System.import("app/modules/MoM.CMS/pages/adminmodules").then(c => c["AdminModulesComponent"])
    }),
    new AsyncRoute({
        path: "/reports",
        name: "AdminReports",
        useAsDefault: false,
        data: { includeInMenu: true, icon: "fa fa-sitemap fa-2x", title: "Reports" },
        loader: () => System.import("app/modules/MoM.CMS/pages/adminreports").then(c => c["AdminReportsComponent"])
    }),
    new AsyncRoute({
        path: "/blog",
        name: "AdminBlog",
        useAsDefault: false,
        data: { includeInMenu: false, icon: "fa fa-book", title: "Blog" },
        loader: () => System.import("app/modules/MoM.Blog/pages/admin").then(c => c["AdminComponent"])
    }),
    new AsyncRoute({
        path: "/blog/post",
        name: "AdminBlogPostCreate",
        useAsDefault: false,
        data: { includeInMenu: false, icon: "" },
        loader: () => System.import("app/modules/MoM.Blog/pages/adminpost").then(c => c["AdminPostComponent"])
    }),
    new AsyncRoute({
        path: "/blog/post/:postId",
        name: "AdminBlogPostEdit",
        useAsDefault: false,
        data: { includeInMenu: false, icon: "" },
        loader: () => System.import("app/modules/MoM.Blog/pages/adminpost").then(c => c["AdminPostComponent"])
    })
])
export class AdminComponent {
    constructor(
        private router: Router
    ) { }

    ngOnInit() {
        console.log(this.router);
    }

    isLinkActive(instruction: any[]): boolean {
        return this.router.isRouteActive(this.router.generate(instruction));
    }
}