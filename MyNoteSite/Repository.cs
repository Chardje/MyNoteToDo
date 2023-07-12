using System.Collections.Generic;

namespace MyNoteSite.Models
{
    public static class Repository
    {
        private static List<IFormCollection> responses = new List<IFormCollection>();
        public static IEnumerable<IFormCollection> Responses => responses;
        public static void AddResponse(IFormCollection response)
        {
            responses.Add(response);
        }

        public static bool IsRegestrated(IFormCollection response) {
            string login = response["Login"];
            if (string.IsNullOrEmpty(login)) { return false; }
            foreach (var item in responses)
            {
                if (item["Login"] == login)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
