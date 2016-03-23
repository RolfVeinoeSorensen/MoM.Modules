import {Http, Headers, HTTP_PROVIDERS} from "angular2/http";
import {Injectable} from "angular2/core";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";


@Injectable()
export class BlogService {
    constructor(private http: Http) { }

    getCategoriesWithPostcount(pageSize: number, onNext: (json: Category) => void) {
        this.http.get("blog/api/categorieswithpostcount/?pageSize=" + pageSize).map(response => response.json()).subscribe(onNext);
    }

    getTagsWithPostcount(pageSize: number, onNext: (json: Tag) => void) {
        this.http.get("blog/api/tagswithpostcount/?pagesize=" + pageSize).map(response => response.json()).subscribe(onNext);
    }

    getPostById(postId: number, onNext: (json: Post) => void) {
        this.http.get("blog/api/adminpost/?postId=" + postId).map(response => response.json()).subscribe(onNext);
    }

    getPost(year: number, month:  number, urlSlug: string, onNext: (json: Post) => void) {
        this.http.get("blog/api/post/?year=" + year + "&month=" + month + "&urlSlug=" + urlSlug).map(response => response.json()).subscribe(onNext);
    }

    addPost(post: Post, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("blog/api/addpost", JSON.stringify(post), { headers }).map(response => response.json()).subscribe(onNext);
    }

    editPost(post: Post, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("blog/api/editpost", JSON.stringify(post), { headers }).map(response => response.json()).subscribe(onNext);
    }

    getLatestsPosts(paging: Paging, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("blog/api/posts", JSON.stringify(paging), { headers }).map(response => response.json()).subscribe(onNext);
    }
}