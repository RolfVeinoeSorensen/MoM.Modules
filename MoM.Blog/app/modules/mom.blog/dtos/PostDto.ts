import {CategoryDto} from "CategoryDto";
import {PostTagDto} from "PostTagDto";

export interface PostDto { 
    postId: number;
    title: string;
    teaser: string;
    content: string;
    meta: string;
    urlSlug: string;
    isPublished: number;
    postedDate: Date;
    modifiedDate: Date;
    category: CategoryDto;
    postTags: PostTagDto[];
    day: number;
    month: number;
    year: number;
    monthName: string;
    monthNameShort: string;
    }
