import {Http, Headers, HTTP_PROVIDERS} from "angular2/http";
import {Injectable} from "angular2/core";
import {Paging, PagingWithSort} from "../interfaces/iPager";
import {User, Role} from "../interfaces/iIdentity";
import 'rxjs/Rx';


@Injectable()
export class AdminPageService {
    constructor(private http: Http) { }

    getUsers(pager: PagingWithSort, onNext: (json: User) => void) {
        this.http.get("api/identity/users/?pageNo=" + pager.pageNo + "&pageSize=" + pager.pageSize + "&sortColumn=" + pager.sortColumn + "&sortByAscending=" + pager.sortByAscending).map(response => response.json()).subscribe(onNext);
    }

    getRoles(pager: PagingWithSort, onNext: (json: Role) => void) {
        this.http.get("api/identity/roles/?pageNo=" + pager.pageNo + "&pageSize=" + pager.pageSize + "&sortColumn=" + pager.sortColumn + "&sortByAscending=" + pager.sortByAscending).map(response => response.json()).subscribe(onNext);
    }
}