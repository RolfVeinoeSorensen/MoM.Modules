import {Component, OnInit} from "@angular/core";
import {RouterLink} from "@angular/router-deprecated";

@Component({
    selector: "mvc",
    templateUrl: "/cms/pages/home",
    directives: [RouterLink]
})
export class HomeComponent implements OnInit {
    //message: string;

    //constructor() { }

    ngOnInit() {
        //this.message = "Welcome to EasyModules.NET"
    }
}