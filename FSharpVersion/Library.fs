module FSharpVersion.Test

open FSharp.Data
    
type VehiclesData = XmlProvider<Sample="data.xml">

type Item =
    { id: int
      licensePlate: string option
      latitude: decimal
      longitude: decimal
      timeStamp: string option }

let data = VehiclesData.GetSample()

let test =
    data.Cars
    |> Array.map (fun x ->
        { id = x.TmNumber
          licensePlate = x.NumberPlate.String
          latitude = x.Info.Lat
          longitude = x.Info.Lng
          timeStamp = x.Info.Time.String })