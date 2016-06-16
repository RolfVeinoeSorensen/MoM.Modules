
// $Classes/Enums/Interfaces(filter)[template][separator]
// filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
// template: The template to repeat for each matched item
// separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

// More info: http://frhagn.github.io/Typewriter/

import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions, RequestOptionsArgs} from "@angular/http";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";

// import {parseModel} from '../models/ModelHelper';



import {PagingWithSortDto} from "../dtos/PagingWithSortDto";
import {PostDto} from "../dtos/PostDto";
import {CategoryDto} from "../dtos/CategoryDto";
import {TagDto} from "../dtos/TagDto";

@Injectable()
export class AdminService {
constructor(private _http: Http) { }

    public createPost = (post: PostDto) : Observable<Response> => {
        return this._http.request(`createpost`, new RequestOptions({
            method: "put",
            body: JSON.stringify(post)
        }));
    }
    public updatePost = (post: PostDto) : Observable<Response> => {
        return this._http.request(`updatepost`, new RequestOptions({
            method: "put",
            body: JSON.stringify(post)
        }));
    }
    public deletePost = (post: PostDto) : Observable<Response> => {
        return this._http.request(`deletepost`, new RequestOptions({
            method: "put",
            body: JSON.stringify(post)
        }));
    }
    public createCategory = (category: CategoryDto) : Observable<Response> => {
        return this._http.request(`createcategory`, new RequestOptions({
            method: "put",
            body: JSON.stringify(category)
        }));
    }
    public updateCategory = (category: CategoryDto) : Observable<Response> => {
        return this._http.request(`updatecategory`, new RequestOptions({
            method: "put",
            body: JSON.stringify(category)
        }));
    }
    public deleteCategory = (category: CategoryDto) : Observable<Response> => {
        return this._http.request(`deletecategory`, new RequestOptions({
            method: "put",
            body: JSON.stringify(category)
        }));
    }
    public createTag = (tag: TagDto) : Observable<Response> => {
        return this._http.request(`createtag`, new RequestOptions({
            method: "put",
            body: JSON.stringify(tag)
        }));
    }
    public updateTag = (tag: TagDto) : Observable<Response> => {
        return this._http.request(`updatetag`, new RequestOptions({
            method: "put",
            body: JSON.stringify(tag)
        }));
    }
    public deleteTag = (tag: TagDto) : Observable<Response> => {
        return this._http.request(`deletetag`, new RequestOptions({
            method: "put",
            body: JSON.stringify(tag)
        }));
    }

    public posts = (paging: PagingWithSortDto) : Observable<PostDto[]> => {
        return this._http.request(`posts`, new RequestOptions({
            method: "post",
            body: JSON.stringify(paging)
        })).map(res => (<PostDto[]>res.json()));
    }
    public categories = (pageNo: number, pageSize: number, sortColumn: string, sortByAscending: boolean) : Observable<CategoryDto[]> => {
        return this._http.request(`categories?pageNo=${pageNo}&pageSize=${pageSize}&sortColumn=${sortColumn}&sortByAscending=${sortByAscending}`, new RequestOptions({
            method: "get",
            body: JSON.stringify(null)
        })).map(res => (<CategoryDto[]>res.json()));
    }

}