//import {Component, OnInit} from "@angular/core";
//import {CORE_DIRECTIVES} from "@angular/common";
//import {BlogService} from "../service/blog";
//import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";

//@Component({
//    selector: "blog-tagcloud",
//    templateUrl: "/blog/widgets/tagcloud",
//    providers: [BlogService],
//    directives: CORE_DIRECTIVES
//})
//export class PostContentComponent implements OnInit {
//    isLoading: boolean = false;

//    constructor(private service: BlogService) { }

//    ngOnInit() {
//        this.get();
//    }

//    get() {
//        this.isLoading = true;
//        this.service.getTagsWithPostcount(this.pageSize, json => {
//            if (json) {
//                this.tags = json;
//                this.isLoading = false;
//            }
//        });
//    }
//}