https://jakubgiedzicz.github.io/Find-Genre/
API endpoints: 
Genre:
1. GetById - Id(>0) returns a Genre with its Tags, Subgenres and Subgenres' Tags.
2. GetAll - Return a list of all Genres with its Tags, Subgenres and Subgenres' Tags.
3. GetByTags - Return a list of all Genres that have specified Tags with its Tags, Subgenres and Subgenres' Tags.
4. Create - Check if Genre with specified name exists, must enter list of TagIds, if one of them doesnt exist return null. Create new Genre with specified Tags and if Parents provided, update their Subgenres, return that Genre.
5. Update - Check if Genre with specified Id(>0) exists, set new properties, if Tags provided update relationship, if subgenres provided update relationship.
6. Delete - Check if Genre with specified Id(>0) exists, delete it.
