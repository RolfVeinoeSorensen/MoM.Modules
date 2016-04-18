import {Http, Headers, HTTP_PROVIDERS} from "angular2/http";
import {Injectable} from "angular2/core";
import {Paging, PagingWithSort, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import 'rxjs/Rx';

@Injectable()
export class BlogAdminService {
    constructor(private http: Http) { }

    getPosts(paging: Paging, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/posts", JSON.stringify(paging), { headers }).map(response => response.json()).subscribe(onNext);
    }

    getPostById(postId: number, onNext: (json: Post) => void) {
        this.http.get("api/blog/public/adminpost/?postId=" + postId).map(response => response.json()).subscribe(onNext);
    }

    createPost(post: Post, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/addpost", JSON.stringify(post), { headers }).map(response => response.json()).subscribe(onNext);
    }

    updatePost(post: Post, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/editpost", JSON.stringify(post), { headers }).map(response => response.json()).subscribe(onNext);
    }

    getCategories(paging: PagingWithSort, onNext: (json: Category) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.get("api/blog/admin/categories/?pageNo=" + paging.pageNo + "&pageSize=" + paging.pageSize + "&sortColumn=" + paging.sortColumn + "&sortByAscending=" + paging.sortByAscending).map(response => response.json()).subscribe(onNext);
    }

    createCategory(category: Category, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/createcategory", JSON.stringify(category), { headers }).map(response => response.json()).subscribe(onNext);
    }

    updateCategory(category: Category, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/updatecatagory", JSON.stringify(category), { headers }).map(response => response.json()).subscribe(onNext);
    }

    deleteCategory(category: Category, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/deletecatagory", JSON.stringify(category), { headers }).map(response => response.json()).subscribe(onNext);
    }
}