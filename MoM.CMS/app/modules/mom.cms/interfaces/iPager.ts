export interface Paging {
    pageNo: number;
    pageSize: number;
}

export interface PagingWithSort {
    pageNo: number;
    pageSize: number;
    sortColumn: string;
    sortByAscending: boolean;
}