namespace TallyCnt

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

type Resources = TallyCnt.Resource

[<Activity (Label = "TallyCnt", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1
    let mutable counter:int = 0

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resources.Layout.Main)

        // Get our button from the layout resource, and attach an event to it
        //let button = this.FindViewById<Button>(Resources.Id.myButton)
        //button.Click.Add (fun args -> 
        //    button.Text <- sprintf "%d clicks!" count
        //    count <- count + 1
        //)

        let cntText = this.FindViewById<TextView>(Resources.Id.counterText);
        let incrementButton = this.FindViewById<ImageButton>(Resources.Id.imageButton2);
        incrementButton.Click.Add(fun args ->
            counter <- counter + 1
            cntText.Text <- sprintf "%d" counter
        )

        let dencrementButton = this.FindViewById<ImageButton>(Resources.Id.imageButton1);
        dencrementButton.Click.Add(fun args ->
            counter <- counter - 1
            if counter < 0
            then counter <- 0;
            cntText.Text <- sprintf "%d" counter
        )



