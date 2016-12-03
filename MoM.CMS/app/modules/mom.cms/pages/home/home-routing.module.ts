import { NgModule }            from "@angular/core";
import { RouterModule }        from "@angular/router";

import { HomeComponent }    from "./home.component";

@NgModule({
    imports: [RouterModule.forChild([
        { path: "home", component: HomeComponent }
    ])],
    exports: [RouterModule]
})
export class HomeRoutingModule { }


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/