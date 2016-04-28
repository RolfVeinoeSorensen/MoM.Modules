import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
import { Collapse } from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: "cms-editor-html",
    templateUrl: "/cms/widgets/editorHtml",
    //providers: [BlogPublicService],
    directives: [CORE_DIRECTIVES, Collapse]
})
export class EditorHtmlComponent implements OnInit {
    isLoading: boolean = false;
    isCollapsed: boolean = false;
    constructor() { }

    ngOnInit() {

    }
}