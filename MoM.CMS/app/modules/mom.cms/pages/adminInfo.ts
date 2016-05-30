import {Component, OnInit} from "@angular/core";
import {AlertComponent} from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "mom-admin-info",
    directives: [AlertComponent],
    templateUrl: "/cms/pages/admininfo"
})
export class AdminInfoComponent implements OnInit {
    //message: string;

    //constructor() { }

    ngOnInit() {
        //this.message = "Welcome to EasyModules.NET"
    }
}