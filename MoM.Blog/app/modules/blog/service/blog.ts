import "rxjs/Rx"
import {Http, Headers, HTTP_PROVIDERS} from "angular2/http";
import {Injectable} from "angular2/core";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";


@Injectable()
export class BlogService {
    constructor(private http: Http) { }

    getCategories(onNext: (json: Category) => void) {
        this.http.get("api/blog/categorieswithpostcount").map(response => response.json()).subscribe(onNext);
    }

    getPosts(paging: Paging, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/posts", JSON.stringify(paging), { headers }).map(response => response.json()).subscribe(onNext);
    }
}