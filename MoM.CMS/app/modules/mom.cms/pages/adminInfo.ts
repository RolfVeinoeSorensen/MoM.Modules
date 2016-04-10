import {Component, OnInit} from "angular2/core";
import {Alert} from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: "mom-admin-info",
    directives: [Alert],
    templateUrl: "/cms/pages/admininfo"
})
export class AdminInfoComponent implements OnInit {
    //message: string;

    constructor() { }

    ngOnInit() {
        //this.message = "Welcome to EasyModules.NET"
    }
}