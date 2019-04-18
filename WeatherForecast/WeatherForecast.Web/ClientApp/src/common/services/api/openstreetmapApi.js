import axios from "axios";

export const instance = axios.create({
  baseURL: "https://nominatim.openstreetmap.org",
  params: {
    format: "json"
  }
});

export const search = ({ city, zipCode }) =>
  instance.get("/search", {
    params: {
      city,
      postalcode: zipCode,
      addressdetails: 1
    }
  });
