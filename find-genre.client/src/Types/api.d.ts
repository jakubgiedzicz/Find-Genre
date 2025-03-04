export interface tagType {
    name: string,
    tagId: number
}
export interface subgenreType {
    tags: tagType[],
    description: string,
    examples: string[],
    name: string,
    popularity?: number,
    promoted?: string[],
    subgenreId: number
}
export interface genreType {
    tags: tagType[],
    description: string,
    examples: string[],
    name: string,
    popularity: number,
    promoted?: string[],
    subgenres?: subgenreType[],
    genreId: number
}