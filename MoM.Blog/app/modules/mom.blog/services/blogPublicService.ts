import {Http, Headers, HTTP_PROVIDERS} from "@angular/http";
import {Injectable} from "angular2/core";
import {Paging, Category, Tag, Post, PostTag} from "../interfaces/iblog";
import 'rxjs/Rx';

@Injectable()
export class BlogPublicService {
    constructor(private http: Http) { }

    getCategoriesWithPostcount(pageSize: number, onNext: (json: Category) => void) {
        this.http.get("api/blog/public/categorieswithpostcount/?pageSize=" + pageSize).map(response => response.json()).subscribe(onNext);
    }

    getTagsWithPostcount(pageSize: number, onNext: (json: Tag) => void) {
        this.http.get("api/blog/public/tagswithpostcount/?pagesize=" + pageSize).map(response => response.json()).subscribe(onNext);
    }

    getPost(year: number, month:  number, urlSlug: string, onNext: (json: Post) => void) {
        this.http.get("api/blog/public/post/?year=" + year + "&month=" + month + "&urlSlug=" + urlSlug).map(response => response.json()).subscribe(onNext);
    }

    getLatestsPosts(paging: Paging, onNext: (json: Post) => void) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post("api/blog/public/posts", JSON.stringify(paging), { headers }).map(response => response.json()).subscribe(onNext);
    }
}