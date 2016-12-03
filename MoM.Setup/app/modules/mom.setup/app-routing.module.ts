import { NgModule }             from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { DatabaseComponent }    from "./pages/database/database.component";

export const routes: Routes = [
  { path: "", component: DatabaseComponent},
  //{ path: "crisis", loadChildren: "app/crisis/crisis.module#CrisisModule" },
  //{ path: "heroes", loadChildren: "app/hero/hero.module#HeroModule" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/