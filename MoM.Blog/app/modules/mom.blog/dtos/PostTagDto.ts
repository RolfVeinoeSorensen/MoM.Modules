import {PostDto} from "./PostDto";
import {TagDto} from "./TagDto";

export interface PostTagDto {
    postId: number;
    post: PostDto;
    tagId: number;
    tag: TagDto;
    }
