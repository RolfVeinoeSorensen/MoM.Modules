import "rxjs/Rx"
import {Http} from "angular2/http";
import {Injectable} from "angular2/core";

@Injectable()
export class BlogService {
    constructor(private http: Http) { }

    getCategories(onNext: (json: any) => void) {
        this.http.get("api/blog/categories").map(response => response.json()).subscribe(onNext);
    }

    getLatestsPosts(onNext: (json: any) => void) {
        this.http.get("api/blog/categories").map(response => response.json()).subscribe(onNext);
    }
}