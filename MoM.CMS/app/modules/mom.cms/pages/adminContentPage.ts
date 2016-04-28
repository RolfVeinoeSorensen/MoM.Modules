import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
//import {BlogAdminService} from "../services/blogadminservice";
import {Paging, PagingWithSort} from "../interfaces/ipager";
import {Router, RouteParams} from 'angular2/router';
import {Dragula, DragulaService} from 'ng2-dragula/ng2-dragula';
import { ACCORDION_DIRECTIVES } from 'ng2-bootstrap/ng2-bootstrap';
import { EditorHtmlComponent } from '../widgets/editorhtml';
//import {Codeblock} from 'ng2-prism/codeblock';
//import {Csharp, Css, Javascript, Json} from 'ng2-prism/languages';

@Component({
    selector: "cms-admin-content-page",
    templateUrl: "/cms/pages/AdminContentPage",
    //providers: [BlogAdminService],
    directives: [ACCORDION_DIRECTIVES, CORE_DIRECTIVES, Dragula, EditorHtmlComponent], //, Csharp, Css, Javascript, Json]
    viewProviders: [DragulaService]
})
export class AdminContentPageComponent implements OnInit {
    page: any;
    isLoading: boolean = false;
    pageId: number;
    isNewPage: boolean = true;
    pageTitle: string;
    submitted: boolean = false;

    constructor(
        //private service: BlogAdminService,
        private router: Router,
        private routeParams: RouteParams,
        private dragulaService: DragulaService
    )
    {
        this.pageId = +this.routeParams.get("pageId");
        //setup dragNdrop for creating content
        dragulaService.setOptions('page-bag', {
            copy: true,
            copySortSource: true
        })
        //determine if drop is allowed
        dragulaService.drop.subscribe((value) => {
            this.onDrop(value);
        });
    }
    //(0 - bagname, 1 - el, 2 - target, 3 - source, 4 - sibling)
    private onDrop(value) {
        if (value[2] == null) //dragged outside any of the bags
            return;
        if (value[2].id !== "content" && value[2].id !== value[3].id) //dragged to a container that should not add the element
            value[1].remove();
    }
    ngOnInit() {
        if (this.pageId !== 0) {
            this.isNewPage = false;
            this.pageTitle = "Edit page";
            this.get();
        }
        else {
            this.pageTitle = "Create page";
            this.page = { title: '', pageId: 0, content: '', teaser: '', isPublished: 0, meta: '', day: 0, modifiedDate: new Date(), month: null, monthName: '', monthNameShort: '', postedDate: new Date(), postTags: [], urlSlug: '', year: 0 };
            this.isLoading = false;
        }   
    }

    get() {
        this.isLoading = true;
        //this.service.getPostById(this.postId, json => {
        //    if (json) {             
        //        this.post = json;
        //        this.isLoading = false;
        //    }
        //});
    }

    onSubmit() {
        this.submitted = true;
        console.log("submit");
        console.log(this.page);
        console.log(this.isNewPage);
    }

    onAddPage(page: any) {
        this.isLoading = true;
        //this.service.createPost(this.post, json => {
        //    if (json) {
        //        this.post = json;
        //        this.isLoading = false;
        //    }
        //});
    }

    onUpdatePage(page: any) {
        console.log("update");
        console.log(page);
        this.isLoading = true;
        //this.service.updatePost(this.post, json => {
        //    if (json) {
        //        this.post = json;
        //        this.isLoading = false;
        //    }
        //});
    }

    onCancel() {
        this.router.navigate(['../AdminContentPages']);
    }
}