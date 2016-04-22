import {Component, OnInit} from "angular2/core";
import {CORE_DIRECTIVES} from "angular2/src/common/directives/core_directives";
//import {BlogAdminService} from "../services/blogadminservice";
import {Paging, PagingWithSort} from "../interfaces/ipager";
import {Router, RouteParams} from 'angular2/router';
import {Dragula, DragulaService} from 'ng2-dragula/ng2-dragula';
//import {Codeblock} from 'ng2-prism/codeblock';
//import {Csharp, Css, Javascript, Json} from 'ng2-prism/languages';

@Component({
    selector: "cms-admin-content-page",
    templateUrl: "/cms/pages/AdminContentPage",
    //providers: [BlogAdminService],
    directives: [CORE_DIRECTIVES, Dragula], //, Csharp, Css, Javascript, Json]
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
        private routeParams: RouteParams
    )
    {
        this.pageId = +this.routeParams.get("pageId");
    }

    ngOnInit() {
        console.log(this.pageId);
        if (this.pageId !== 0) {
            this.isNewPage = false;
            this.pageTitle = "Edit post";
            this.get();
        }
        else {
            this.pageTitle = "Create post";
            this.page = { title: '', pageId: 0, content: '', category: null, teaser: '', isPublished: 0, meta: '', day: 0, modifiedDate: new Date(), month: null, monthName: '', monthNameShort: '', postedDate: new Date(), postTags: [], urlSlug: '', year: 0 };
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

    onAddPost(page: any) {
        this.isLoading = true;
        //this.service.createPost(this.post, json => {
        //    if (json) {
        //        this.post = json;
        //        this.isLoading = false;
        //    }
        //});
    }

    onUpdatePost(page: any) {
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