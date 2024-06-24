const tblBlog = "blogs";
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

// createBlog();
readBlog();
// updateBlog("28644325-3878-41bf-8d98-249c6ee98d3f","twl","twl","twl");
// deleteBlog("c79e4469-626b-4b79-b0ee-4007c70bf58c");

function createBlog(){
    const blogs = localStorage.getItem(tblBlog);
    // console.log(blogs);
    let lst = [];

    if(blogs !== null){
        lst = JSON.parse(blogs);
    }

    const requestModel = {
        id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    };

    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog,jsonBlog);     
}

function readBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function updateBlog(id,title,author,content){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    var items = lst.filter(x => x.id === id) 
    // console.log(items);   
    // console.log(items.length);   

    if(items.length == 0){
        console.log("No Dat Found!");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x => x.id == id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog,jsonBlog);    
}

function deleteBlog(id){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    
    var items = lst.filter(x => x.id === id) 
    // console.log(items);   
    // console.log(items.length);   

    if(items.length == 0){
        console.log("No Dat Found!");
        return;
    }

    lst = lst.filter(x => x.id !== id)    
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog,jsonBlog);   
}