
/*function myFunction(x) {
  if (x.matches)
  { // If media query matches
    document.location= "profile.html";
  }
}

var x = window.matchMedia("(max-width: 1200px)")
myFunction(x) // Call listener function at run time
x.addListener(myFunction) // Attach listener function on state changes
*/


window.addEventListener("scroll",function(){
  let menuArea=document.getElementById('menu-area');
  var btns = document.getElementsByClassName("highlight");
  if (window.pageYOffset>0)
  {
    menuArea.classList.add("cus-nav");
  }
  else
   {
    menuArea.classList.remove("cus-nav");
  }

  if (window.pageYOffset >= 0 && window.pageYOffset <694) {
      btns[0].classList.add("active");
      btns[1].classList.remove("active");
      btns[2].classList.remove("active");
      btns[3].classList.remove("active");
      btns[4].classList.remove("active");
  }
  if (window.pageYOffset >=694 && window.pageYOffset <1198 ) {
    btns[0].classList.remove("active");
    btns[1].classList.add("active");
    btns[2].classList.remove("active");
    btns[3].classList.remove("active");
    btns[4].classList.remove("active");
  }
  if (window.pageYOffset >=1198 && window.pageYOffset <2133) {
    btns[0].classList.remove("active");
    btns[1].classList.remove("active");
    btns[2].classList.add("active");
    btns[3].classList.remove("active");
    btns[4].classList.remove("active");
  }
  if (window.pageYOffset >=2133 && window.pageYOffset <5000) {
    btns[0].classList.remove("active");
    btns[1].classList.remove("active");
    btns[2].classList.remove("active");
    btns[3].classList.add("active");
    btns[4].classList.remove("active");
  }
  if (window.pageYOffset >=5000) {
    btns[0].classList.remove("active");
    btns[1].classList.remove("active");
    btns[2].classList.remove("active");
    btns[3].classList.remove("active");
    btns[4].classList.add("active");
  }


});



var header = document.getElementById("menu-area");
var btns = header.getElementsByClassName("highlight");
for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function() {
  var current = document.getElementsByClassName("active");
  current[0].className = current[0].className.replace(" active", "");
  this.className += " active";
  console.log("rk"+window.pageYOffset);
  });
}

  const icon=document.querySelector('.navLinesMobile');
  const navLinks=document.querySelector('.nav-links');
  const links=document.querySelectorAll('.nav-links li');
  icon.addEventListener("click",()=>{
    navLinks.classList.toggle("open");
    links.forEach(link=>{
      link.classList.toggle("fade");
    });
  });

  navLinks.addEventListener("click",()=>{
    if ($(window).width()<=768) {
      navLinks.classList.toggle("open");
      links.forEach(link=>{
        link.classList.toggle("fade");
      });
    }
  });



//Scroll Animation on Profile
const hero=document.querySelector('.hero');
const slider=document.querySelector('.rightOn');
const logo=document.querySelector('.logo');
const nav=document.querySelector('#menu-area');
const avatar=document.querySelector('#avatar');
const t1=new TimelineMax();
t1.fromTo(hero,1.2,{height:"0%"},{height:"75%",ease:Power2.easeInOut})
  t1.fromTo(hero,1.2,{width:"100%"},{width:"30%",ease:Power2.easeInOut})
.fromTo(slider,1.2,{x:"-100%"},{x:"0%",ease:Power2.easeInOut},"-=2.4")
.fromTo(avatar,1,{opacity:0,x:30},{opacity:1,x:0},"-=0.5")
.fromTo(nav,1,{opacity:0,x:30},{opacity:1,x:0},"-=0.5");

/* Hero wodth Controller*/
if ($(window).width() > 768) {
  t1.fromTo(hero,0.1,{width:"100%"},{width:"30%",ease:Power2.easeInOut});
}
else {
t1.fromTo(hero,0.1,{width:"100%"},{width:"80%",ease:Power2.easeInOut});
}
window.addEventListener("resize",function(){
  if ($(window).width() < 768) {
    t1.fromTo(hero,0.1,{width:"100%"},{width:"80%",ease:Power2.easeInOut});
  }
  else {
  t1.fromTo(hero,0.1,{width:"100%"},{width:"30%",ease:Power2.easeInOut});
  }
});

//var ctrl = new ScrollMagic.Controller();
//new ScrollMagic.Scene({
//    triggerElement: ".parallax",
//    triggerHook: "onLeave",
//  duration:"90%"
//  })
//  .setTween(t1)
// .addTo(ctrl);


//Horizontal Scrolling Experience Section
    console.clear();
    var controller = new ScrollMagic.Controller();
    var sections = document.querySelectorAll("section");
    var tl = new TimelineMax();
    var offset = window.innerHeight;

    for (let i = 1; i < sections.length; i++) {
      tl.from(sections[i], 1, { yPercent:100, ease: Linear.easeNone }, "+=1");
    }
    new ScrollMagic.Scene({
      triggerElement: "#pinMaster",
      triggerHook: "onLeave",
      duration: "250%"
    })
      .setPin("#pinMaster")
      .setTween(tl)
      .addTo(controller);


//Swiper Slide Skill Cards
var swiper = new Swiper('.swiper-container', {
  effect: 'coverflow',
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: 'auto',
  initialSlide: 3,
  coverflowEffect: {
    rotate: 50,
    stretch: 0,
    depth: 100,
    modifier: 1,
    slideShadows : true,
  },
  pagination: {
    el: '.swiper-pagination',
    clickable: true,
  },
});


//Navbar Highlighter Logic


//ModalProfile
var modal = document.getElementById('idProfModalRK');
// Get the image and insert it inside the modal - use its "alt" text as a caption
var img = document.getElementById('profileId');
var modalImg = document.getElementById("idrkProfile");
var captionText = document.getElementById("caption");
img.onclick = function(){
    modal.style.display = "block";
    modalImg.src = "./resources/rk-Profile.jpg";
    //modalImg.alt = this.alt;
    //captionText.innerHTML = this.alt;
}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("closeProfile")[0];

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}
