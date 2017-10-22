using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaCheckout : MonoBehaviour {

    string STORE_ID = "59ec329ef36d28647542d5cd";
    string URL = "https://mighty-castle-94058.herokuapp.com/api/v1/";
    string API = "/pay";

    IEnumerator GetSuggestions() {
        string resource = "suggestions";
        WWWForm form = new WWWForm();
        string items = "[\"apple\"]";
        form.AddField("items", items);

        WWW www = new WWW(URL + resource, form);
        yield return www;

        // process result suggestions
        if (www.error == null) {
            print(www.text);
        } else
            print(www.error);
    }

    IEnumerator GetPromotions() {
        string resource = "stores/";
        string path = "/promotions";

        WWW www = new WWW(URL + resource + STORE_ID + path);
        yield return www;
        
        // process results from promotions
        if (www.error == null) {
            print(www.text);
        } else {
            print(www.error);
        }
    }

    IEnumerator GetItems() {
        string resource = "stores/";
        string path = "/items";

        WWW www = new WWW(URL + resource + STORE_ID + path);
        yield return www;

        // process items
        if (www.error == null) {
            print(www.text);
        } else {
            print(www.error);
        }
    }

    IEnumerator GetStore() {
        string resource = "stores/";

        WWW www = new WWW(URL + resource + STORE_ID);
        yield return www;

        // process store
        if (www.error == null) {
            print(www.text);
        } else {
            print(www.error);
        }
    }

    IEnumerator ClaimPromotion() {
        string resource = "promotions";
        string offerId = "/89430609";

        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");

        string ourPostData = "{\"firstName\": \"Homer\",\"lastName\": \"Simpson\", \"userKey\": \"54893584\", \"cardNumber\": \"4321114156363002\", \"nameOnCard\": \"US - BANK\", \"contactType\": \"SMS\", \"contactValue\": \"54893534\", \"contactCountryCode\": \"1\", \"isContactVerified\": \"false\", \"isPreferred\": \"true\", \"subtotal\": \"100\"}";

        byte[] pData = System.Text.Encoding.ASCII.GetBytes(ourPostData.ToCharArray());
        WWW www = new WWW(URL + resource + offerId, pData, postHeader);

        yield return www;

        // process result suggestions
        if (www.error == null) {
            print(www.text);
        } else {
            print(www.error);
        }
    }

    IEnumerator Checkout() {
        string resource = "stores/";
        WWWForm form = new WWWForm();
        form.AddField("amount", "12.45");
        form.AddField("cardNumber", "4321114156363002");
        form.AddField("cardExpirationMonth", "08");
        form.AddField("cardExpirationYear", "19");

        //        Hashtable headers = form.headers;
        //    byte[] rawData = form.data;

        print(URL + resource + STORE_ID + API);

        WWW www = new WWW(URL + resource + STORE_ID + API, form);
        yield return www;

        // process result from pay
        if (www.error == null) {
            print(www.text);
        } else
            print(www.error);
    }

    public void CallCheckout() {
        StartCoroutine(Checkout());
    }

    public void CallGetSuggestions() {
        StartCoroutine(GetSuggestions());
    }

    public void CallGetPromotions() {
        StartCoroutine(GetPromotions());
    }

    public void CallGetItems() {
        StartCoroutine(GetItems());
    }

    public void CallGetStore() {
        StartCoroutine(GetStore());
    }

    public void CallClaimPromotion() {
        StartCoroutine(ClaimPromotion());
    }

    void Start() {
        //CallCheckout ();
        //CallGetSuggestions();
        //CallGetPromotions();
        //CallGetItems();
        //CallGetStore();
        //CallClaimPromotion();
    }
}
