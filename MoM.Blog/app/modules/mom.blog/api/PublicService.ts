
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



import {CategoryDto} from "../dtos/CategoryDto";
import {PagingDto} from "../dtos/PagingDto";
import {PostDto} from "../dtos/PostDto";
import {TagDto} from "../dtos/TagDto";

@Injectable()
export class PublicService {
    constructor(private _http: Http) { }
    
    public categoriesWithPostCount = (pageSize: number) : Observable<CategoryDto[]> => {
        return this._http.request(`categorieswithpostcount?pageSize=${pageSize}`, new RequestOptions({
            method: "get",
            body: JSON.stringify(null)
        })).map(res => (<CategoryDto[]>res.json()));
    }
    public posts = (paging: PagingDto) : Observable<PostDto[]> => {
        return this._http.request(`posts`, new RequestOptions({
            method: "post",
            body: JSON.stringify(paging)
        })).map(res => (<PostDto[]>res.json()));
    }
    public tagsWithPostCount = (pageSize: number) : Observable<TagDto[]> => {
        return this._http.request(`tagswithpostcount?pageSize=${pageSize}`, new RequestOptions({
            method: "get",
            body: JSON.stringify(null)
        })).map(res => (<TagDto[]>res.json()));
    }
    public post = (year: number, month: number, urlSlug: string) : Observable<PostDto> => {
        return this._http.request(`post?year=${year}&month=${month}&urlSlug=${urlSlug}`, new RequestOptions({
            method: "get",
            body: JSON.stringify(null)
        })).map(res => (<PostDto>res.json()));
    }
    
}