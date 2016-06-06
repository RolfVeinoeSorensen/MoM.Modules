
export interface PagingDto { 
    pageNo: number;
    pageSize: number;
    }
export interface PagingWithSortDto { 
    pageNo: number;
    pageSize: number;
    sortColumn: string;
    sortByAscending: boolean;
    }
