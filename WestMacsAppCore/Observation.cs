/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:13 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:13 
 */
using System;
using System.Text.Json.Serialization;

public class Observation
{
    private int _authorName;
    private string _note;
    private DateTime _logDate;

    [JsonPropertyName("author-name")]
    public int AuthorName { get => _authorName; set => _authorName = value; }
    [JsonPropertyName("note")]
    public string Note { get => _note; set => _note = value; }
    [JsonPropertyName("log_date")]
    public DateTime LogDate { get => _logDate; set => _logDate = value; }
}