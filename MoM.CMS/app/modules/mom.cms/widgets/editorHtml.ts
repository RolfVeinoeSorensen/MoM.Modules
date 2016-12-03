import {Component, OnInit} from "@angular/core";
import { CollapseModule } from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "cms-editor-html",
    templateUrl: "/cms/widgets/editorHtml"
})
export class EditorHtmlComponent implements OnInit {
    isLoading: boolean = false;
    isCollapsed: boolean = false;
    //constructor() {   }
    ngOnInit() {
        this.isLoading = false;
    }
}