import {Component, OnInit} from "@angular/core";
import {CORE_DIRECTIVES} from "@angular/common";
import { CollapseDirective } from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "cms-editor-html",
    templateUrl: "/cms/widgets/editorHtml",
    //providers: [BlogPublicService],
    directives: [CORE_DIRECTIVES, CollapseDirective]
})
export class EditorHtmlComponent implements OnInit {
    isLoading: boolean = false;
    isCollapsed: boolean = false;
    //constructor() {   }
    ngOnInit() {
        this.isLoading = false;
    }
}