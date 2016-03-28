export interface Post {
    postId: number;
    title: string;
    teaser?: string;
    content: string;
    meta?: string;
    urlSlug?: string;
    isPublished?: number;
    postedDate?: Date;
    modifiedDate?: Date;
    category?: Category;
    postTags?: Array<PostTag>
    day?: number;
    month?: number;
    year?: number;
    monthName?: string;
    monthNameShort?: string;
}

export interface Category {
    categoryId: number;
    name: string;
    urlSlug: string;
    description: string;
    postCount: number;
}

export interface Tag {
    tagId: number;
    name: string;
    urlSlug: string;
    description: string;
    className: string;
    postCount: number;
}

export interface PostTag {
    postId: number;
    post: Post;
    tagId: number;
    tag: Tag;
}


export interface Paging {
    pageNo: number;
    pageSize: number;
}