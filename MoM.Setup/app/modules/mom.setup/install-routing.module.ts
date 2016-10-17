import { NgModule }             from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { InstallComponent }   from "./pages/install";

const routes: Routes = [
    { path: "", redirectTo: "/pages/install", pathMatch: "full" },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class InstallRoutingModule { }