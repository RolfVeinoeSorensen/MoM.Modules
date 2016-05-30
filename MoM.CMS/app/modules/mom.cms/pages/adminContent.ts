import {Component, OnInit} from "@angular/core";
import {AlertComponent} from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "mom-admin-content",
    directives: [AlertComponent],
    templateUrl: "/cms/pages/admincontent"
})
export class AdminContentComponent implements OnInit {
    //message: string;

    //constructor() { }

    ngOnInit() {
        //this.message = "Welcome to EasyModules.NET"
    }
}