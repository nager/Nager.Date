window.getNagerApi = function (endPoint) {
    return fetch(endPoint, { credentials: 'same-origin' }).then(function (response) {
        if (response.ok) {
            return response.json();
        }
        if (response.bodyUsed) {
            response.text().then(function (errBody) { console.error(errBody); });
        }
        throw new Error(response.statusText);
    })
}

/*
Above from original effort after realising it might not suppoert older browsers and no babel transpiling in build
    const getNagerApi = async (endPoint) => {
      const response = await fetch(endPoint, { credentials: 'same-origin' });
      if (!response.ok) {
        if (response.bodyUsed) {
          console.error(await response.text());
        }
        throw new Error(response.statusText);
      }
      return await response.json();
    }
*/
