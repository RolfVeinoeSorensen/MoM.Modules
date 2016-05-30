import {Http, Headers, HTTP_PROVIDERS} from "@angular/http";
import {Injectable} from "@angular/core";
import {Paging, PagingWithSort} from "../interfaces/iPager";
import {User, Role} from "../interfaces/iIdentity";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";


@Injectable()
export class AdminIdentityService {
    constructor(private http: Http) { }

    getUsers(pager: PagingWithSort, onNext: (json: User) => void) {
        this.http.get("api/identity/users/?pageNo=" + pager.pageNo + "&pageSize=" + pager.pageSize + "&sortColumn=" + pager.sortColumn + "&sortByAscending=" + pager.sortByAscending).map(response => response.json()).subscribe(onNext);
    }

    getRoles(pager: PagingWithSort, onNext: (json: Role) => void) {
        this.http.get("api/identity/roles/?pageNo=" + pager.pageNo + "&pageSize=" + pager.pageSize + "&sortColumn=" + pager.sortColumn + "&sortByAscending=" + pager.sortByAscending).map(response => response.json()).subscribe(onNext);
    }
}